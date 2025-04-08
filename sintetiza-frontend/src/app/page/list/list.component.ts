import { SintetizeService } from './../../services/sintetize.service';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AnswerModalComponent } from '../../components/answer-modal/answer-modal.component';
import { IQuestion } from '../../interfaces/question.interface';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-list',
  imports: [MatIconModule],
  templateUrl: './list.component.html',
  styleUrl: './list.component.css'
})
export class ListComponent implements OnInit{

  public questions: IQuestion[] = [];

  constructor(
    private service: SintetizeService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.service.getQuestions()
    .subscribe(question => {
      this.questions = question;
    })
  }

  abrirModal(question: IQuestion) {
    const dialogReference = this.dialog.open(AnswerModalComponent, {
      width: '400px'
    });

    dialogReference.componentInstance.question = question;    

  }
}
