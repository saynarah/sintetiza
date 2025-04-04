import { Component, OnInit } from '@angular/core';
import { SpeechBubbleComponent } from "../../components/speech-bubble/speech-bubble.component";
import { InputAnswerComponent } from '../../components/input-answer/input-answer.component';
import { BubbleEnum } from '../../enum/bubble.enum';
import { ReplyBubbleComponent } from "../../components/reply-bubble/reply-bubble.component";

@Component({
  selector: 'app-home',
  imports: [SpeechBubbleComponent, InputAnswerComponent, ReplyBubbleComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  bubbleQuestion: BubbleEnum = BubbleEnum.question;
  bubbleAnswer: BubbleEnum = BubbleEnum.answer;

  constructor() {}

  ngOnInit(): void {
    this.bubbleQuestion = BubbleEnum.question;
    this.bubbleAnswer = BubbleEnum.answer;
  }



}
