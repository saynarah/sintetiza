
export interface IAnswer {
    id?: string;
    questionPartitionKey: string;
    words: string[];
    actor: string;
}