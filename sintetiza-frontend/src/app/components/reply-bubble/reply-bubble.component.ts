import { Component, Input, OnInit } from '@angular/core';
import { IQuestion } from '../../interfaces/question.interface';

@Component({
  selector: 'app-reply-bubble',
  imports: [],
  templateUrl: './reply-bubble.component.html',
  styleUrl: './reply-bubble.component.css',
})
export class ReplyBubbleComponent implements OnInit {

  @Input() question: IQuestion = {
    id: '',
    description: '',
    dateTime: new Date(),
    anwers: []
  };

  ngOnInit(): void {
    console.log('resposta', this.question);
  }
}
