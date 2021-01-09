export interface User {
  id: number;
  username: string;
  knowAs: string;
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
}
