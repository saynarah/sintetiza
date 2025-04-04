import { IAnswer } from "./answer.interface";

export interface IQuestion {
    id: string;
    description: string;
    dateTime: Date;
    anwers: IAnswer[];
}