using ItemCatalogAPI.Interface;
using ItemCatalogAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItemCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TmplAttrController : ControllerBase
    {
        private readonly ITmplAttrRepository _TmplAttrRepository;
        private readonly ILogger<TmplAttrRepository> _logger;

        public TmplAttrController(ITmplAttrRepository TmplAttrRepository, ILogger<TmplAttrRepository> logger)
        {
            _TmplAttrRepository = TmplAttrRepository;
            _logger = logger;
        }

        [HttpGet("get-tmpl-attr")]
        public async Task<IActionResult> getTmplAttr()
        {
            var TmplAttr = await _TmplAttrRepository.GetAllTmplAttrAsync();
            return Ok(TmplAttr);
        }

        [HttpGet("{parMessageId}")]
        public async Task<IActionResult> GetAttributeValue(string parMessageId)
        {
            if (string.IsNullOrWhiteSpace(parMessageId))
            {
                return BadRequest("Parameter 'parMessageId' is required.");
            }

            try
            {
                var attributeValues = await _TmplAttrRepository.GetAttributeValueAsync(parMessageId);

                if (attributeValues == null || !attributeValues.Any())
                {
                    return NotFound("No attributes found for the given 'parMessageId'.");
                }

                return Ok(attributeValues);
            }
            catch (Exception ex)
            {
                
                _logger.LogError($"An error occurred while fetching attribute values: {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

    }
}
