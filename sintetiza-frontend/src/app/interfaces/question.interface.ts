import { IAnswer } from "./answer.interface";

export interface IQuestion {
    id: string;
    description: string;
    rowKey: string,
    anwers: IAnswer[];
}