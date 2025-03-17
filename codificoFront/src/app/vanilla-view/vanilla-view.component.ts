import { Component, ElementRef, ViewChild, AfterViewInit } from '@angular/core';
import * as d3 from 'd3';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-vanilla-view',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './vanilla-view.component.html',
  styleUrls: ['./vanilla-view.component.css']
})
export class VanillaViewComponent implements AfterViewInit {
  @ViewChild('chartContainer', { static: false }) chartContainer!: ElementRef;
  data: number[] = [];
  inputData: string = '';

  ngAfterViewInit() {
    this.drawChart();
  }

  updateChart() {
    if (!this.inputData) return;
    this.data = this.inputData.split(',')
      .map(num => parseInt(num.trim(), 10))
      .filter(num => !isNaN(num));

    this.drawChart();
  }

  drawChart() {
    if (!this.chartContainer) return;
    const element = this.chartContainer.nativeElement;
    d3.select(element).selectAll('*').remove();
    const width = 400;
    const height = this.data.length * 30;
    const svg = d3.select(element)
      .append('svg')
      .attr('width', width)
      .attr('height', height);

    const colorScale = d3.scaleOrdinal(d3.schemeCategory10);

    const xScale = d3.scaleLinear()
      .domain([0, d3.max(this.data) || 1])
      .range([0, width - 50]);

    svg.selectAll('rect')
      .data(this.data)
      .enter()
      .append('rect')
      .attr('x', 10)
      .attr('y', (d, i) => i * 30)
      .attr('width', d => xScale(d))
      .attr('height', 25)
      .attr('fill', (d, i) => colorScale(i.toString()));

    svg.selectAll('text')
      .data(this.data)
      .enter()
      .append('text')
      .attr('x', d => xScale(d) + 15)
      .attr('y', (d, i) => i * 30 + 18)
      .text(d => d)
      .attr('font-size', '14px')
      .attr('fill', 'black');
  }
}
