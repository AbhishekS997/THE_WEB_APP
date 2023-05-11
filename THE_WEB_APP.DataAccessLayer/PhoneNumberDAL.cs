namespace THE_WEB_APP.DataAccessLayer
{
    public class PhoneNumberDAL
    {
        public async Task<ActionResult<IEnumerable<PhoneNumberListItem>>> GetPhoneNumberListItems()
        {
            if (_context.PhoneNumberListItems == null)
            {
                return NotFound();
            }
            return await _context.PhoneNumberListItems.ToListAsync();
        }
    }
}