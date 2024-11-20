using BloodBankAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BloodBankController : ControllerBase
    {
        private readonly List<BloodBankEntry> _bloodBankEntries;
        private static readonly object _lock = new object();

        public BloodBankController(List<BloodBankEntry> bloodBankEntries)
        {
            _bloodBankEntries = bloodBankEntries;
        }

        // Update status for expiration
        private void UpdateStatuses()
        {
            lock (_lock)
            {
                foreach (var entry in _bloodBankEntries)
                {
                    if (entry.ExpirationDate < DateTime.UtcNow)
                        entry.Status = "Expired";
                }
            }
        }


        // POST: api/bloodbank
        [HttpPost]
        public IActionResult Create([FromBody] BloodBankEntry entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            lock (_lock)
            {
                entry.Id = Guid.NewGuid(); // Auto-generate ID
                _bloodBankEntries.Add(entry);
            }

            return CreatedAtAction(nameof(GetById), new { id = entry.Id }, entry);
        }

        // GET: api/bloodbank
        [HttpGet]
        public IActionResult GetAll([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string sortBy = "DonorName")
        {
            if (page <= 0 || size <= 0)
            {
                return BadRequest("Page and size must be greater than 0.");
            }
            UpdateStatuses();
            IEnumerable<BloodBankEntry> sortedEntries = sortBy.ToLower() switch
            {
                "bloodtype" => _bloodBankEntries.OrderBy(e => e.BloodType),
                "collectiondate" => _bloodBankEntries.OrderBy(e => e.CollectionDate),
                "quantity" => _bloodBankEntries.OrderBy(e => e.Quantity),
                _ => _bloodBankEntries.OrderBy(e => e.DonorName) // Default to sorting by DonorName
            };

            var paginatedEntries = sortedEntries
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();

            return Ok(new
            {
                TotalCount = _bloodBankEntries.Count,
                PageNumber = page,
                PageSize = size,
                Data = paginatedEntries
            });
        }

        // GET: api/bloodbank/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var entry = _bloodBankEntries.FirstOrDefault(e => e.Id == id);
            if (entry == null)
                return NotFound(new { Message = $"Blood entry with ID {id} not found." });

            return Ok(entry);
        }

        // PUT: api/bloodbank/{id}
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] BloodBankEntry updatedEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            lock (_lock)
            {
                var entry = _bloodBankEntries.FirstOrDefault(e => e.Id == id);
                if (entry == null)
                    return NotFound(new { Message = $"Blood entry with ID {id} not found." });

                // Update properties
                entry.DonorName = updatedEntry.DonorName;
                entry.Age = updatedEntry.Age;
                entry.BloodType = updatedEntry.BloodType;
                entry.ContactInfo = updatedEntry.ContactInfo;
                entry.Quantity = updatedEntry.Quantity;
                entry.CollectionDate = updatedEntry.CollectionDate;
                entry.ExpirationDate = updatedEntry.ExpirationDate;
                entry.Status = updatedEntry.Status;
            }

            return NoContent();
        }

        // DELETE: api/bloodbank/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            lock (_lock)
            {
                var entry = _bloodBankEntries.FirstOrDefault(e => e.Id == id);
                if (entry == null)
                    return NotFound(new { Message = $"Blood entry with ID {id} not found." });

                _bloodBankEntries.Remove(entry);
            }

            return NoContent();
        }

        // GET: api/bloodbank/search
        [HttpGet("search")]
        public IActionResult Search(
            [FromQuery] string bloodType = null,
            [FromQuery] string status = null,
            [FromQuery] string donorName = null,
            [FromQuery] int? minQuantity = null,
            [FromQuery] int? maxQuantity = null)
        {
            UpdateStatuses();
            var results = _bloodBankEntries.AsQueryable();

            if (!string.IsNullOrWhiteSpace(bloodType))
            {
                results = results.Where(e => e.BloodType.Equals(bloodType, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                results = results.Where(e => e.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(donorName))
            {
                results = results.Where(e => e.DonorName.Contains(donorName, StringComparison.OrdinalIgnoreCase));
            }

            if (minQuantity.HasValue)
            {
                results = results.Where(e => e.Quantity >= minQuantity.Value);
            }

            if (maxQuantity.HasValue)
            {
                results = results.Where(e => e.Quantity <= maxQuantity.Value);
            }

            return Ok(results.ToList());
        }
    }
}
