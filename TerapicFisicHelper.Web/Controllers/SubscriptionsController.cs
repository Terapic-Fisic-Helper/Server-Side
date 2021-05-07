using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TerapicFisicHelper.Data;
using TerapicFisicHelper.Entities;
using TerapicFisicHelper.Web.Models;

namespace TerapicFisicHelper.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly DbContextTerapicFisicHelperApp _context;

        public SubscriptionsController(DbContextTerapicFisicHelperApp context)
        {
            _context = context;
        }

        // GET: api/Subscriptions
        [HttpGet]
        public async Task<IEnumerable<SubscriptionModel>> GetSubscriptions()
        {
            var subscriptionList = await _context.Subscriptions.ToListAsync();

            return subscriptionList.Select(c => new SubscriptionModel
            {
                CustomerId = c.CustomerId,
                SubscriptionPlanId = c.SubscriptionPlanId,
                ExpiryDate = c.ExpiryDate,
                StartDate = c.StartDate
            });
        }

        // POST: api/Subscriptions
        [HttpPost]
        public async Task<IActionResult> PostSubscription([FromBody] CreateSubscriptionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Subscription subscription = new Subscription
            {
                CustomerId = model.CustomerId,
                SubscriptionPlanId = model.SubscriptionPlanId,
                ExpiryDate = model.ExpiryDate,
                StartDate = model.StartDate
            };

            _context.Subscriptions.Add(subscription);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // DELETE: api/Subscriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscription([FromRoute] int id)
        {
            var subscription = await _context.Subscriptions.FindAsync(id);

            if (subscription == null)
                return NotFound();

            _context.Subscriptions.Remove(subscription);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpGet("customers/{customerId}")]
        public async Task<IActionResult> GetAllByCustomerId(int customerId)
        {
            var subscriptionPlans = await _context.Customers.FindAsync(customerId);

            if (subscriptionPlans == null)
            {
                return NotFound();
            }

            return Ok(new CustomerModel
            {
                Id = subscriptionPlans.Id,
                Description = subscriptionPlans.Description,
                UserId = subscriptionPlans.UserId
            });
        }

        [HttpGet("plans/{subscriptionPlanId}")]
        public async Task<IActionResult> GetAllBySubscriptionPlanId(int subscriptionPlanId)
        {
            var customers = await _context.SubscriptionPlans.FindAsync(subscriptionPlanId);

            if (customers == null)
            {
                return NotFound();
            }

            return Ok(new SubscriptionPlanModel
            {
                Id = customers.Id,
                Name = customers.Name,
                Description = customers.Description,
                Cost = customers.Cost
            });
        }
    }
}
