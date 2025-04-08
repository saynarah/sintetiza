import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IQuestion } from '../../interfaces/question.interface';

@Component({
  selector: 'app-speech-bubble',
  imports: [CommonModule],
  templateUrl: './speech-bubble.component.html',
  styleUrl: './speech-bubble.component.css'
})
export class SpeechBubbleComponent {

  @Input() question?: IQuestion = {
    id: '',
    description: '',
    dateTime: new Date(),
    anwers: []
  };

}
