using BlazorApp3.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


//using LangChain.Chains.LLM;
//using LangChain.Chains.Sequentials;
//using LangChain.Prompts;
//using LangChain.Providers.OpenAI;
//using LangChain.Schema;

//using var httpClient = new HttpClient();
//var llm = new Gpt35TurboModel("api-key", httpClient);

//var firstTemplate = "What is a good name for a company that makes {product}?";
//var firstPrompt = new PromptTemplate(new PromptTemplateInput(firstTemplate, new List<string>(1) { "product" }));

//var chainOne = new LlmChain(new LlmChainInput(llm, firstPrompt)
//{
//	OutputKey = "company_name"
//});

//var secondTemplate = "Write a 20 words description for the following company:{company_name}";
//var secondPrompt = new PromptTemplate(new PromptTemplateInput(secondTemplate, new List<string>(1) { "company_name" }));

//var chainTwo = new LlmChain(new LlmChainInput(llm, secondPrompt));

//var overallChain = new SequentialChain(new SequentialChainInput(new[]
//{
//	chainOne,
//	chainTwo
//}, new[] { "product" }));

//var result = await overallChain.CallAsync(new ChainValues(new Dictionary<string, object>(1)
//{
//	{ "product", "colourful socks" }
//}));

//Console.WriteLine(result.Value["text"]);
//Console.WriteLine("Test");