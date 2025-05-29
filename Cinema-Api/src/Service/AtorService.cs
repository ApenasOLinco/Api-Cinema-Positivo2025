using AutoMapper;
using Cinema_Api.src.Config.Mapper;
using Cinema_Api.src.Context;
using Cinema_Api.src.Exceptions;
using Cinema_Api.src.Models;
using Cinema_Api.src.Models.DTOs.Filter;
using Cinema_Api.src.Models.DTOs.Get;
using Cinema_Api.src.Models.DTOs.HttpPatch;
using Cinema_Api.src.Models.DTOs.Post;
using Microsoft.EntityFrameworkCore;

namespace Cinema_Api.src.Service;

public class AtorService(
    MasterContext masterContext
)
{
    private readonly MasterContext _masterContext = masterContext;

    private readonly Mapper Mapper = new(new MapperConfiguration(AutoMapperConfig.Configurar));
    
    public Ator NovoAtor(AtorPostDTO atorDto)
	{
		var existe = _masterContext
			.Ator.AsEnumerable()
			.Where(filmeBd =>
				filmeBd.Nome.Equals(atorDto.Nome, StringComparison.OrdinalIgnoreCase)
				&& filmeBd.DataNasc == atorDto.DataNasc
			)
			.Any();

		if (existe)
			throw new AlreadyExistsException(
				"Um Ator com nome e data de Nascimento iguais aos fornecidos já existe."
			);

		var ator = Mapper.Map<AtorPostDTO, Ator>(atorDto);

		_masterContext.SaveChanges();
		
		return ator;
	}
    public AtorGetDTO UmAtor(int Id)
    {
        var ator = _masterContext
            .Ator.Include(a => a.Nome)
            .Include(a => a.DataNasc)
            .Where(a => a.Id == Id)
            .FirstOrDefault();

        return ator is null
            ? throw new EntityNotFoundException($"Uma entidade Ator de Id {Id} não existe.")
            : Mapper.Map<Diretor, DiretorGetDTO>(ator);
    }
}