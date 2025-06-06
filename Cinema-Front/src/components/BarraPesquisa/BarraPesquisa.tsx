import { useState, type ChangeEvent } from "react";

interface Props {
	onChange?: (query: string) => void;
	placeholder?: string;
}

function BarraPesquisa({ onChange, placeholder }: Props) {
	const [query, setQuery] = useState("");

	const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
		setQuery(e.target.value);

		// Chama a função se ela nãp for nula
		onChange && onChange(e.target.value);
	}

	return (
		<input
			className="pesquisa-input"
			type="text"
			placeholder={placeholder || "Procurar..."}
			value={query}
			onChange={handleChange}
		/>
	)
}

export default BarraPesquisa;