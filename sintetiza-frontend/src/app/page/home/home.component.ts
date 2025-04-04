import { Component, OnInit } from '@angular/core';
import { SpeechBubbleComponent } from "../../components/speech-bubble/speech-bubble.component";
import { InputAnswerComponent } from '../../components/input-answer/input-answer.component';
import { ReplyBubbleComponent } from "../../components/reply-bubble/reply-bubble.component";
import { SintetizeService } from '../../services/sintetize.service';
import { IQuestion } from '../../interfaces/question.interface';

@Component({
  selector: 'app-home',
  imports: [SpeechBubbleComponent, InputAnswerComponent, ReplyBubbleComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  
  public question!: IQuestion;

  constructor(private service: SintetizeService) {}

  ngOnInit(): void {
    this.service.getQuestionRound().subscribe(question => {this.question = question});
    console.log(this.question)
  }


}
