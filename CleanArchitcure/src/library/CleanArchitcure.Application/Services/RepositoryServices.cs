
using System;
using System.Collections.Generic;
using AutoMapper;
using CleanArchitcure.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitcure.Application.Services;

public class RepositoryServices<TEntiy, IModel> : IRepositoryServices<TEntiy, IModel>where TEntiy : class,new() where IModel : class
{
	private readonly IMapper mapper;
	private readonly ApplicationDbContext _context;

	public RepositoryServices(IMapper mapper, ApplicationDbContext context)
	{
		this.mapper = mapper;
		_context = context;
		_dbset=_context.Set<TEntiy>();
	}
	private DbSet<TEntiy> _dbset { get; } 

	public async Task<IModel> DeltedASync(int id, CancellationToken cancellationToken)
	{
		var entity = await _dbset.FindAsync(id);
		if (entity == null)
		{
			return null;
		}
		_dbset.Remove(entity);
		await _context.SaveChangesAsync(cancellationToken);
		var deleteModel = mapper.Map<TEntiy, IModel>(entity);
		return deleteModel;
	}

	public async Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellationToken)
	{
		var entites = await _dbset.ToListAsync(cancellationToken);
		if (entites == null) return null;
		var data = mapper.Map<IList<IModel>>(entites);
		return data;
	}

	public async Task<IModel> GetByIdAsync(int id, CancellationToken cancellationToken)
	{
		var entity = await _dbset.FindAsync(id);
		if (entity == null) return null;
		var model = mapper.Map<TEntiy, IModel>(entity);
		return model;
	}

	public async Task<IModel> InsertAsync(int id, IModel model, CancellationToken cancellationToken)
	{
		var entity = mapper.Map<IModel, TEntiy>(model);
		_dbset.Add(entity);
		await _context.SaveChangesAsync(cancellationToken);
		var insertModel = mapper.Map<TEntiy, IModel>(entity);
		return insertModel;
	}

	public async Task<IModel> UpdatedAsync(int id, IModel model, CancellationToken cancellationToken)
	{
		var entity = await _dbset.FindAsync(id);
		if (entity == null)
		{
			return null;
		}
		mapper.Map(model, entity);

		await _context.SaveChangesAsync(cancellationToken);

		var updatedModel = mapper.Map<TEntiy, IModel>(entity);
		return updatedModel;
	}
}
