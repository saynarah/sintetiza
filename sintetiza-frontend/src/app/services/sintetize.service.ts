import { IAnswer } from './../interfaces/answer.interface';
import { IQuestion } from './../interfaces/question.interface';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { url } from 'inspector';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SintetizeService {

    private API = "http://localhost:7034/api";

    constructor(private http: HttpClient){}

    getQuestionRound() : Observable<IQuestion>{
        let id = 1;
        const url = `${this.API}/GetQuestion/${id}`;
        return this.http.get<IQuestion>(url);
    }
    
    getQuestions() : Observable<IQuestion[]>{
        const url = `${this.API}/GetAllQuestion`;
        return this.http.get<IQuestion[]>(url);
    }
    
    saveWord(answer: IAnswer) : Observable<any>{
        console.log('chamou', answer)
        const url = `${this.API}/CreateAnswer`;
        console.log('url', url)
        const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        return this.http.post<any>(url, answer, { headers });
    }
}
