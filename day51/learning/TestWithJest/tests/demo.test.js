const { JSDOM } = require('jsdom');
const fs = require('fs');
const path = require('path');
//import {JSDOM} from 'jsdom';

test('simple button click', () => {
    const html = fs.readFileSync(path.resolve(__dirname, '../index.html'), 'utf8');
    const js = fs.readFileSync(path.resolve(__dirname, '../index.js'), 'utf8');
    const dom = new JSDOM(html, { runScripts: 'dangerously', resources: 'usable' });
    const script = dom.window.document.createElement('script');
    script.textContent = js;
    dom.window.document.body.appendChild(script);
    dom.window.document.getElementById('btn').click();
    const actual = dom.window.document.getElementById('demo').innerHTML;
    expect(actual).toBe('Hello World');
})