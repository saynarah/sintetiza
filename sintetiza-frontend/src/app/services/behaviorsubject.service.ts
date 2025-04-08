import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BehaviorSubjectService {

    private wordBehaviorSubject = new BehaviorSubject<string>('');
    
    constructor(){}

    setAnswers(word: string) {
        this.wordBehaviorSubject.next(word);
    }
    
    getAnswers() {
        return this.wordBehaviorSubject;
    }

}