import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Component, Input, input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IQuestion } from '../../interfaces/question.interface';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-answer-modal',
  imports: [CommonModule, MatDialogModule, MatButtonModule],
  templateUrl: './answer-modal.component.html',
  styleUrl: './answer-modal.component.css'
})
export class AnswerModalComponent implements OnInit{

  @Input() question: IQuestion = {
      id: '',
      rowKey: '',
      description: '',
      anwers: []
    };

  constructor(private matdialog: MatDialog) { }

  ngOnInit(): void {
    console.log('question', this.question)
  }
}
