namespace CleanArchitcure.Application.Services;

public interface IRepositoryServices<TEntity,IModel>where TEntity : class ,new() where IModel : class
{
	Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellationToken);
	Task<IModel> GetByIdAsync(int id, CancellationToken cancellationToken);
	Task<IModel> DeltedASync(int id, CancellationToken cancellationToken);
	Task<IModel> UpdatedAsync(int id, IModel model, CancellationToken cancellationToken);
	Task<IModel> InsertAsync(int id, IModel model, CancellationToken cancellationToken);

}
