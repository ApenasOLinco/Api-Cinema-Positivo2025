using AutoMapper;
using Cinema_Api.src.Models;
using Cinema_Api.src.Models.DTOs.Get;
using Cinema_Api.src.Models.DTOs.Post;

namespace Cinema_Api.src.Config.Mapper;

public class AutoMapperConfig
{
	public static void Configurar(IMapperConfigurationExpression cfg)
	{
		// Diretor
		cfg.CreateMap<Diretor, DiretorGetDTO>();
		cfg.CreateMap<DiretorGetDTO, Diretor>();
		cfg.CreateMap<DiretorPostDTO, Diretor>();

		// Filme
		cfg.CreateMap<FilmePostDTO, Filme>();
		ConfigurarFilmeParaDTO(cfg);
	}

	private static void ConfigurarFilmeParaDTO(IMapperConfigurationExpression cfg)
	{
		cfg.CreateMap<Filme, FilmeGetDTO>()
			.ForMember(
				dest => dest.Generos,
				opt => opt.MapFrom(src => src.FilmesGeneros.Select(fg => fg.Genero.Nome).ToList())
			);
	}
}
