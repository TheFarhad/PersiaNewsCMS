namespace NewsCMS.Endpoint.Controllers;

using Microsoft.AspNetCore.Mvc;
using NewsCMS.Core.Contract.Services.Command;
using NewsCMS.Core.Contract.Services.Query;
using Sky.App.Endpoint.Api.Controller;

[ApiController]
[Route("api/[Controller]")]
public class NewsController : ApiController
{
    [HttpPost("/list-news")]
    public async Task<IActionResult> ListAsync(NewsSearchByTitleQuery query) =>
        await GetAsync<NewsSearchByTitleQuery, NewsSearchByTitlePayload>(query);

    [HttpPost("/add-news")]
    public async Task<IActionResult> CreateAsync(NewsCreateCommand source) =>
        await AddAsync<NewsCreateCommand, NewsCreatePayload>(source);

    [HttpPost("/edit-news")]
    public async Task<IActionResult> EditAsync(NewsEditCommand source) =>
        await AddAsync<NewsEditCommand, NewsEditPayload>(source);

}
