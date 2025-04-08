import { Component, OnInit } from '@angular/core';
import { BehaviorSubjectService } from '../../services/behaviorsubject.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-reply-bubble',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './reply-bubble.component.html',
  styleUrl: './reply-bubble.component.css',
})
export class ReplyBubbleComponent implements OnInit {

  public words: string[] = [];

  constructor(private wordBehaviorSubject: BehaviorSubjectService) {}

  ngOnInit(): void {
    this.wordBehaviorSubject.getAnswers()
      .subscribe(word => {
        this.words.push(word)
      }); 
  }
}
