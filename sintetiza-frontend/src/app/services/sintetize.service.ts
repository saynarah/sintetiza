import { IAnswer } from './../interfaces/answer.interface';
import { IQuestion } from './../interfaces/question.interface';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import axios from 'axios';

@Injectable({
  providedIn: 'root',
})
export class SintetizeService {

    private API = "https://sintetize20250409230156.azurewebsites.net/api"//"http://localhost:7034/api";

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
    
    saveWord(answer: IAnswer){
        const url = `${this.API}/CreateAnswer`;
        
        axios.post(url, answer)
        .then(response => {
          response = response.data;
          console.log('Salvo com sucesso:', response.data);
        })
        .catch(error => {
          console.error('Erro na requisição:', error);
        });
    }
}
