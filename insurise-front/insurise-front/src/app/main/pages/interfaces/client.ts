
export enum genderType{
    Male,
    Female
}
export interface IClient{
    clientId :number,
    idCard: string;
    firstName: string;
    lastName: string;
    birthDate: string;
    gender: genderType;
    phoneNumber: number;
    mail: string;
}