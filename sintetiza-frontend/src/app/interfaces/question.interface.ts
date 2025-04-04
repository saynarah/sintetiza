import { IAnswer } from "./answer.interface";

export interface IQuestion {
    Id: string;
    Description: string;
    DateTime: Date;
    Anwers: IAnswer[];
}