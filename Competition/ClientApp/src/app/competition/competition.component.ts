import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


declare function openDialog() : any;


@Component({
  selector: 'app-competition',
  templateUrl: './competition.component.html',
  styleUrls: ['./competition.component.css'],
  
})
export class CompetitionComponent{
  
 
  public forecasts: CompetitionData
  public resultArray : any;
  private baseUrl: string;
  public modal : string;
  

  constructor(private http: HttpClient) { this.baseUrl =  document.getElementsByTagName('base')[0].href }
  
  searchCompetition( id : string ) {
    this.http.get<CompetitionData>(this.baseUrl + 'api/Competition/' + id).subscribe(result => {
      if(result.message == null){
        this.forecasts = result;
        

        this.resultArray = [];
        if(result.standings[0].table.length != 0){
          for(var i in result.standings[0].table){
            this.resultArray.push(result.standings[0].table[i]);
          }
        }
      }
       else
      {
        this.modal = result.message;
        openDialog();
        this.forecasts = null;
        this.resultArray = null;
      } 
    }, 
    error => {
      this.modal = error.message;
      openDialog();
    });
  
  };
}
interface CompetitionData {
  filters : {}
  competition : {id : number, area : {id : number, name : string}, name : string, code : string, emblemUrl : string, plan : string, lastUpdate : string}
  seasons : {id:number, startDate:string, endDate:string, currentMatchday: string, winner:{id:number, name:string, shortName:string, tla:string, crestUrl: string}}[]    
  standings : {stage : string, type : string, group : string, table : {position : number, team : {id : number, name : string, crestUrl : string}, playedGames : number, won : number, draw : number, lost : number, points : number, goalsFor : number, goalsAgainst : number, goalDifference : number}[]}
  message : string
  error : string
}
