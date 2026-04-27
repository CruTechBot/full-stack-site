export type NewUserDTO = {
  name: string;
  password: string;
  email: string;
};

export type UserLoginDTO = {
  password: string;
  email: string;
};

export type CommentDTO = {
  id: number,
  userId: number;
  name: string;
  comment: string;
  created: Date;
}

export type userTokenDTO = {
  token: string;
  userId: number;
}