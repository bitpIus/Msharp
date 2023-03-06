using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Msharp.Application.Repositories;
using Msharp.Domain.Dto;

namespace Msharp.V1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FactoryController : ControllerBase
{
    private readonly IFactoryRepository _repository;
    private readonly IMapper _mapper;

    public FactoryController(IFactoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var factories = _repository.GetAllFactories(trackChanges: false);

        if (factories is null)
            return NotFound();

        var factoriesDto = _mapper.Map<IEnumerable<FactoryDto>>(factories);

        return Ok(factoriesDto);
    }

    [HttpGet("{factoryId}")]
    public IActionResult GetOne(int factoryId)
    {
        var factory = _repository.GetFactory(factoryId, trackChanges: false);

        if (factory is null)
            return NotFound();

        var factoryDto = _mapper.Map<FactoryDto>(factory);

        return Ok(factoryDto);
    }

}