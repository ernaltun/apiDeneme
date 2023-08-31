using apiDeneme.Models;
using apiDeneme.Models.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiDeneme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : Controller
    {
        private readonly DbContextErnet _dbContext;

        public InvoiceController(DbContextErnet dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Invoice>> EkleInvoice(Invoice invoice)
        {
            _dbContext.Invoices.Add(invoice);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(EkleInvoice), new { Id = invoice.InvoiceId }, invoice);
        }
    }
}
