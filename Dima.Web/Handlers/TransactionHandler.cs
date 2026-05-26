using System.Net.Http.Json;
using Dima.Core.Common.Extensions;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Web.Handlers;

public class TransactionHandler(IHttpClientFactory httpClientFactory) : ITransactionHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
    
    public Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionsByPeriodRequest request)
    {
        const string format = "yyyy-MM-dd";
        var startDate = request.StartDate is not null
            ? request.StartDate.Value.ToString(format)
            : DateTime.Now.GetFirstDay().ToString(format);

        var endDate = request.EndDate is not null
            ? request.EndDate.Value.ToString(format)
            : DateTime.Now.GetLastDay().ToString(format);
        
        var url = $"v1/transactions?startDate={startDate}&endDate{endDate}";

        return await _client.GetFromJsonAsync<PagedResponse<List<Transaction>?>>(url)
            ?? new PagedResponse<List<Transaction>>(null, 400, "Não foi possível obter as transações.");

    }
}