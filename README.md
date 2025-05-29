# Api-Cinema-Positivo2025

Repositório para a concretização de um projeto API em grupo advindo da matéria de Tópicos Especiais
de Sistemas no curso de Análise e Desenvolvimeto de Sistemas.

Universidade Positivo, 2025.

## Diagrama de classes da API

```mermaid
classDiagram
  class Filme {
    +id: int
    +titulo: string
    +anoLancamento: int
    +sinopse: string
    +posterURLs: string[]
    +notaIMDB: float
  }

  class Ator {
    +id: int
    +nome: string
    +dataNascimento: Date
  }

  class Diretor {
    +id: int
    +nome: string
    +dataNascimento: string
    +biografia: string
  }

  class Genero {
    +id: int
    +nome: string
  }

  Filme "1..*" -- "*" Ator : foiInterpretadoPor
  Filme "1..*" -- "*" Diretor : foiDirigidoPor
  Filme "1..*" -- "*" Genero : possui
```
