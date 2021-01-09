export interface User {
  id: number;
  username: string;
  knownAs: string;
  age: number;
  gender: string;
  created: Date;
  lastActive: Date;
  photoUrl: string;
  city: string;
  conuntry: string;
  interersts?: string;
  introduction?: string;
  lookingFor?: string;
  //photos?: Photo[];
}
