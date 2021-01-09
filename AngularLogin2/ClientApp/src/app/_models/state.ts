export interface UsState {
  name: string;
  id: number;
}

export class UsaState implements UsState {
  name: string;
  id: number;

  constructor(name: string, id: number) {
    this.name = name;
    this.id = id;
  }
}
