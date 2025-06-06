import type AtorPapel from "../Ator/AtorPapel";
import type DiretorGetResponse from "../Diretor/DiretorGetResponse";

export default interface FilmeGetResponse {
	id: number;
	titulo: string;
	anoLancamento: number;
	sinopse: string;
	notaIMDB: number;
	generos: string[];
	diretor: DiretorGetResponse;
	atores: AtorPapel[];
}