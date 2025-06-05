import type AtorPapel from "../Ator/AtorPapel";
import type DiretorGetResponse from "../Diretor/DiretorGetResponse";

export default interface FilmeGetResponse {
	Id: number;
	Titulo: string;
	AnoLancamento: number;
	Sinopse: string;
	NotaIMDB: number;
	Generos: string[];
	Diretor: DiretorGetResponse;
	Atores: AtorPapel[];
}