import './CartaoFilme.css';
import type FilmeGetResponse from "../../models/Filme/FilmeGetResponse";

interface Props {
	filme: FilmeGetResponse,
}

function CartaoFilme({ filme }: Props) {

	return (
		<div className="cartao-filme">
			<div className="filme-poster">
				<img src="/images/placeholder-image.png" alt={`Poster do filme ${filme.titulo}`} />
			</div>
			
			<div className="filme-info">
				<h3>{filme.titulo}</h3>
				<p>{filme.sinopse}</p>
			</div>
		</div>
	)
}

export default CartaoFilme;