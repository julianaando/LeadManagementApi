namespace LeadManagementApi.Caching
{
	public interface ICachingService
	{
	  Task SetAsync(string entity, int id, string value);
	  Task<string?> GetAsync(string entity, int id);
		Task InvalidateAsync(string entity, int id);
	}
}