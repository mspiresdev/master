import { Autor } from './autor';
import { Assunto } from './assunto';

export class Livro {
  id: number;
  titulo: string;
  editora: string;
  edicao: number;
  anoPublicacao: string;
  autors: Autor[];
  assuntos: Assunto[]
}
