using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using THE_WEB_APP.Models;

namespace THE_WEB_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberListItemsController : ControllerBase
    {
        private readonly PhoneNumberListContext _context;

        public PhoneNumberListItemsController(PhoneNumberListContext context)
        {
            _context = context;
        }

        // GET: api/PhoneNumberListItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneNumberListItem>>> GetPhoneNumberListItems()
        {
          if (_context.PhoneNumberListItems == null)
          {
              return NotFound();
          }
            return await _context.PhoneNumberListItems.ToListAsync();
        }

        // GET: api/PhoneNumberListItems/5
        [HttpGet("id")]
        public async Task<ActionResult<PhoneNumberListItem>> GetPhoneNumberListItem(int id)
        {
          if (_context.PhoneNumberListItems == null)
          {
              return NotFound();
          }
            var phoneNumberListItem = await _context.PhoneNumberListItems.FindAsync(id);

            if (phoneNumberListItem == null)
            {
                return NotFound();
            }

            return phoneNumberListItem;
        }

        // PUT: api/PhoneNumberListItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoneNumberListItem(int id, PhoneNumberListItem phoneNumberListItem)
        {
            if (id != phoneNumberListItem.ID)
            {
                return BadRequest();
            }

            _context.Entry(phoneNumberListItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneNumberListItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PhoneNumberListItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhoneNumberListItem>> PostPhoneNumberListItem(PhoneNumberListItem phoneNumberListItem)
        {
          if (_context.PhoneNumberListItems == null)
          {
              return Problem("Entity set 'PhoneNumberListContext.PhoneNumberListItems'  is null.");
          }
            _context.PhoneNumberListItems.Add(phoneNumberListItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhoneNumberListItem", new { id = phoneNumberListItem.ID }, phoneNumberListItem);
        }

        // DELETE: api/PhoneNumberListItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneNumberListItem(int id)
        {
            if (_context.PhoneNumberListItems == null)
            {
                return NotFound();
            }
            var phoneNumberListItem = await _context.PhoneNumberListItems.FindAsync(id);
            if (phoneNumberListItem == null)
            {
                return NotFound();
            }

            _context.PhoneNumberListItems.Remove(phoneNumberListItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhoneNumberListItemExists(int id)
        {
            return (_context.PhoneNumberListItems?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
