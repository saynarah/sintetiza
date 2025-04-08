import { IQuestion } from './../interfaces/question.interface';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { url } from 'inspector';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SintetizeService {

    private API = "http://localhost:3000/questions";

    constructor(private http: HttpClient){}

    getQuestionRound() : Observable<IQuestion>{
        let id = Math.floor(Math.random() * 4) + 1; /*TODO - Melhorar*/
        const url = `${this.API}/${id}`;
        return this.http.get<IQuestion>(url);
    }

    getQuestions() : Observable<IQuestion[]>{
        return this.http.get<IQuestion[]>(this.API);
    }

    saveWord(question: IQuestion) : Observable<IQuestion>{
        return this.http.put<IQuestion>(this.API, question);
    }
}
