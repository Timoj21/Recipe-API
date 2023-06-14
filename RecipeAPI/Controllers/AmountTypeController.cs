using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeAPI.DTO;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmountTypeController : Controller
    {
        private readonly IAmountTypeRepository _amountTypeRepository;
        private readonly IMapper _mapper;
        public AmountTypeController(IAmountTypeRepository amountTypeRepository, IMapper mapper)
        {
            _amountTypeRepository = amountTypeRepository;
            _mapper = mapper;
        }

        // Get al amount types
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<AmountTypeItem>))]
        public IActionResult GetAmountTypes()
        {
            var amountTypes = _mapper.Map<List<AmountTypeDTO>>(_amountTypeRepository.GetAmountTypes());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(amountTypes);
        }

        // Get amount type by id
        [HttpGet("{amountTypeId}")]
        [ProducesResponseType(200, Type = typeof(AmountTypeItem))]
        [ProducesResponseType(400)]
        public IActionResult GetAmountType(int amountTypeId)
        {
            if (!_amountTypeRepository.AmountTypeExists(amountTypeId))
                return NotFound();

            var amountType = _mapper.Map<AmountTypeDTO>(_amountTypeRepository.GetAmountType(amountTypeId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(amountType);
        }
    }
}
