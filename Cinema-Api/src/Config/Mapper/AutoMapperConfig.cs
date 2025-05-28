using AutoMapper;
using Cinema_Api.src.Models;
using Cinema_Api.src.Models.DTOs;
using Cinema_Api.src.Models.DTOs.Post;

namespace Cinema_Api.src.Config.Mapper;

public class AutoMapperConfig
{
	public static void Configurar(IMapperConfigurationExpression cfg)
	{
		cfg.CreateMap<Diretor, DiretorDTO>();
		cfg.CreateMap<DiretorDTO, Diretor>();
		cfg.CreateMap<FilmePostDTO, Filme>();
		ConfigurarFilmeParaDTO(cfg);
	}

	private static void ConfigurarFilmeParaDTO(IMapperConfigurationExpression cfg)
	{
		cfg.CreateMap<Filme, FilmeDTO>()
			.ForMember(
				dest => dest.Generos,
				opt => opt.MapFrom(src => src.FilmesGeneros.Select(fg => fg.Genero.Nome).ToList())
			);
	}
}
