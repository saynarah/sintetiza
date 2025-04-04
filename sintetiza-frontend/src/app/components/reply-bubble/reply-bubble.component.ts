import { Component, Input } from '@angular/core';
import { IQuestion } from '../../interfaces/question.interface';

@Component({
  selector: 'app-reply-bubble',
  imports: [],
  templateUrl: './reply-bubble.component.html',
  styleUrl: './reply-bubble.component.css'
})
export class ReplyBubbleComponent {

  @Input() question: IQuestion = {
    Id: '',
    Description: '',
    DateTime: new Date(),
    Anwers: []
  };
  
}
