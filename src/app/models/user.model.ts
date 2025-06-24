export interface User {
  id: string;
  username: string;
  email: string;
  password: string;
}

export interface CreateUserDTO extends Omit<User, 'id'> {}
