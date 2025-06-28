export interface User {
  id: string;
  userName: string;
  email: string;
  password: string;
}

export interface CreateUserDTO extends Omit<User, 'id'> {}
