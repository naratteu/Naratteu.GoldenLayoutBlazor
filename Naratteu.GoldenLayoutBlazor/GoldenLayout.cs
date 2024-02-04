using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Naratteu.GoldenLayoutBlazor;

public class GoldenLayout(IJSRuntime jsRuntime) : IAsyncDisposable
{
    readonly Lazy<Task<IJSObjectReference>> moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Naratteu.GoldenLayoutBlazor/golden-layout-blazor.js").AsTask());
    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }

    public async ValueTask InitRfMode(ElementReference target, object config)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync(nameof(InitRfMode), target, config);
    }
}