import { Component, Input } from '@angular/core';
import { FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { IQuestion } from '../../interfaces/question.interface';
import { SintetizeService } from '../../services/sintetize.service';
import { IAnswer } from '../../interfaces/answer.interface';

@Component({
  selector: 'app-input-answer',
  imports: [ ReactiveFormsModule ],
  templateUrl: './input-answer.component.html',
  styleUrl: './input-answer.component.css'
})
export class InputAnswerComponent {

  @Input() question: IQuestion = {
    Id: '',
    Description: '',
    DateTime: new Date(),
    Anwers: []
  };

  public word: FormControl = new FormControl('');
  public words: string[] = [];

  constructor(private service: SintetizeService){}

  public saveWord() {
    if(this.word.valid && this.words.length < 5){//adicionar validador especifico e mensagem de erro quando terminar      
      this.words.push(this.word.value);
      this.word = new FormControl('')
      this.saveAnswer();
    }
  }
  
  private saveAnswer(){
    console.log('questao',this.question);

    if(this.words.length == 5){  
      let anwser: IAnswer = {
        Id: "1",
        Words: this.words,
        Actor: 'Teste'
      }        

      if (!this.question.Anwers) {
        this.question.Anwers = [];
      }
      
      this.question.Anwers.push(anwser);
      this.service.saveWord(this.question);
    }
  }

}
