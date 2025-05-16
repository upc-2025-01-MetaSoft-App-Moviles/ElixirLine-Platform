using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using ElixirLinePlatform.API.VinificationProcess.Domain.Services.AgriculturalActivities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElixirLinePlatform.API.VinificationProcess.Interfaces.REST.AgriculturalActivities
{
    [ApiController]
    [Route("api/parcels")]
    public class ParcelsController : ControllerBase
    {
        private readonly IParcelService _parcelService;

        public ParcelsController(IParcelService parcelService)
        {
            _parcelService = parcelService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "List all parcels")]
        public async Task<ActionResult<IEnumerable<Parcel>>> GetAll()
        {
            var parcels = await _parcelService.ListAsync();
            return Ok(parcels);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a specific parcel by ID")]
        public async Task<ActionResult<Parcel>> GetById(Guid id)
        {
            var parcel = await _parcelService.GetByIdAsync(id);
            if (parcel == null) return NotFound();
            return Ok(parcel);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new parcel")]
        public async Task<ActionResult<Parcel>> Create([FromBody] Parcel parcel)
        {
            var created = await _parcelService.CreateAsync(parcel);
            return CreatedAtAction(nameof(GetById), new { id = created.ParcelId }, created);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing parcel")]
        public async Task<ActionResult<Parcel>> Update(Guid id, [FromBody] Parcel parcel)
        {
            var updated = await _parcelService.UpdateAsync(id, parcel);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a parcel")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleted = await _parcelService.DeleteAsync(id);
            if (deleted == null) return NotFound();
            return NoContent();
        }
    }
}
