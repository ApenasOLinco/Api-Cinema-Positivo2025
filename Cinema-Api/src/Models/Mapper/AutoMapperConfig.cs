using AutoMapper;
using Cinema_Api.src.Models.DTOs;

namespace Cinema_Api.src.Models.Mapper;

public class AutoMapperConfig
{
	public static void Configurar(IMapperConfigurationExpression cfg)
	{
		cfg.CreateMap<Diretor, DiretorDTO>();
		cfg.CreateMap<DiretorDTO, Diretor>();
		cfg.CreateMap<FilmeDTO, Filme>();
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