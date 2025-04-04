import { Component } from '@angular/core';
import { SpeechBubbleComponent } from "../../components/speech-bubble/speech-bubble.component";
import { InputAnswerComponent } from '../../components/input-answer/input-answer.component';

@Component({
  selector: 'app-home',
  imports: [SpeechBubbleComponent, InputAnswerComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
