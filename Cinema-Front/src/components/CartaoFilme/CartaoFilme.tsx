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

			<div className="filme-summary">
				<h3>{filme.titulo}</h3>
				<p>{filme.sinopse}</p>
			</div>

			<table className="filme-info">
				<thead>
					<tr>
						<th>Diretor</th>
						<th>Gêneros</th>
					</tr>
				</thead>
				<tbody>
					<tr>
						<td>{filme.diretor.nome}</td>
						<td>
							<ul>
								{filme.generos.map((genero, index) => (
									<li key={index}>{genero}</li>
								))}
							</ul>
						</td>
					</tr>
				</tbody>
			</table>
		</div>
	)
}

export default CartaoFilme;