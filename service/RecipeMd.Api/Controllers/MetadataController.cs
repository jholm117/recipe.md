using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RecipeMd.Domain.Interfaces;

namespace RecipeMd.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MetadataController : ControllerBase
    {
        private readonly IMetadataPresenter metadataService;

        public MetadataController(IMetadataPresenter metadataService)
        {
            this.metadataService = metadataService;
        }

        [HttpGet]
        public IEnumerable<string> SupportedSites()
        {
            return metadataService.SupportedSites;
        }

    }
}
